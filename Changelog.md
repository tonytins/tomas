# Change Log

## v23.0

- Split versioning systems between kernal and terminal
    - Calendar versioning, `YY.MINOR.MICRO`, for kernal
    - Semantic versioning for terminal
- If the file system is activate, system activity will be logged
- Build number based on commit hash

Due to the huge time skip and architectural changes, I've (retroactively) switched to calendar versioning with ``v0.1`` now known as ``v20.1`` as well.

## v20.1

- Filesystem (based on the Cosmos Wiki [guide](https://csos-guide-to-cosmos.fandom.com/wiki/Getting_Started_-_Materials_and_Setting_Up))
- Semantic versioning
- Replaced BasicApp with AboutApp
- Removd TerminalCancelEventArgs and everything related to it