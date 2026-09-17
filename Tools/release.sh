#!/usr/bin/env bash

set -euo pipefail

if [[ $# -ne 1 ]]; then
    echo "Usage: $0 <version>"
    exit 1
fi

VERSION="${1#v}"
TAG="v${VERSION}"

if [[ ! $VERSION =~ ^[0-9]+\.[0-9]+\.[0-9]+(-[0-9A-Za-z.-]+)?$ ]]; then
    echo "Invalid version: $1"
    exit 1
fi

REPOSITORY_ROOT="$(git -C "$(dirname "$0")" rev-parse --show-toplevel)"
PROJECT="$REPOSITORY_ROOT/Barchart.Common/Barchart.Common.csproj"
RELEASE_NOTES="$REPOSITORY_ROOT/.releases/$VERSION.md"

cd "$REPOSITORY_ROOT"

if [[ $(git branch --show-current) != "main" ]]; then
    echo "Releases must be prepared from the main branch."
    exit 1
fi

if [[ -n $(git status --porcelain) ]]; then
    echo "Commit or stash existing changes before preparing a release."
    exit 1
fi

if [[ ! -f $RELEASE_NOTES ]]; then
    echo "Missing release notes: .releases/$VERSION.md"
    exit 1
fi

if git rev-parse --verify --quiet "refs/tags/$TAG" >/dev/null; then
    echo "Tag already exists locally: $TAG"
    exit 1
fi

git fetch origin main --tags

if [[ $(git rev-parse HEAD) != $(git rev-parse origin/main) ]]; then
    echo "Local main must match origin/main."
    exit 1
fi

if git ls-remote --exit-code --tags origin "refs/tags/$TAG" >/dev/null 2>&1; then
    echo "Tag already exists remotely: $TAG"
    exit 1
fi

RELEASE_VERSION="$VERSION" perl -0pi -e 's|<Version>[^<]+</Version>|<Version>$ENV{RELEASE_VERSION}</Version>|' "$PROJECT"

if ! grep -Fq "<Version>$VERSION</Version>" "$PROJECT"; then
    echo "Failed to update the project version."
    exit 1
fi

git add "$PROJECT"
git commit -m "chore(release): $TAG"
git tag -a "$TAG" -m "$TAG"
git push --atomic origin main "$TAG"

echo "Prepared $TAG. Create a GitHub Release from this tag to publish the package."
