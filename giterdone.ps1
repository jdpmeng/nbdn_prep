$message = read-host "Commit Message"
$branchname = Get-Date -format M.d.yyyy-hh.mm
git add -A
git commit -m "$message"
git checkout master
git pull jp master
git checkout -b $branchname

