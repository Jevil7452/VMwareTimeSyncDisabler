# VMwareTimeSyncDisabler
A tool to disable VMware's automatic time sync in a VM.

Note: The tool only adds the following lines to a .VMX file.:
```time.synchronize.continue = "FALSE"
time.synchronize.restore = "FALSE"
time.synchronize.resume.disk = "FALSE"
time.synchronize.shrink = "FALSE"
time.synchronize.tools.startup = "FALSE"
time.synchronize.tools.enable = "FALSE"
time.synchronize.resume.host = "FALSE"
```
The guest OS can still sync the time in other ways.
