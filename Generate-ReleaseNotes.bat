rem https://github.com/StefH/GitHubReleaseNotes

SET version=0.4.5

GitHubReleaseNotes --output ReleaseNotes.md --skip-empty-releases --exclude-labels question invalid doc --version %version%

GitHubReleaseNotes --output PackageReleaseNotes.txt --skip-empty-releases --exclude-labels question invalid doc --template PackageReleaseNotes.template --version %version%