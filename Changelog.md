# Change Log

## 23.5

- With the help of ChatGPT, the ``IProgram`` interface has been rewritten to handle command line arguments. Being ChatGPT derived, it's still rough around the edges (not sure what to do with ``IArguments`` right now), but it's one hell of a jumping start!
- Speaking of, the CST parser has been rewritten to finally support arguments with the help of ChatGPT too. While I could have always looked at FreeSO's implantation for reference, that code is just awful.  It will be ported back upstream ASAP!

## 23.0

- Split versioning systems between kernal and terminal
    - Calendar versioning, `YY.MINOR.MICRO`, for kernal
    - Semantic versioning for terminal
- If the file system is activate, system activity will be logged
- Build number based on commit hash

Due to the huge time skip and architectural changes, I've (retroactively) switched to calendar versioning with ``v0.1`` now known as ``v20.1`` as well.

## 20.1

- Filesystem (based on the Cosmos Wiki [guide](https://csos-guide-to-cosmos.fandom.com/wiki/Getting_Started_-_Materials_and_Setting_Up))
- Semantic versioning
- Replaced BasicApp with AboutApp
- Removd TerminalCancelEventArgs and everything related to it