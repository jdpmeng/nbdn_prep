$branchname = Get-Date -format M.d.yy-hh.mm
$message = read-host "Commit Message"
git add -A
git commit -m "$message"
git checkout master
git checkout -b $branchname
git pull jp master
