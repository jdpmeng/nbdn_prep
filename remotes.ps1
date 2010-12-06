("lalitaraju","parimala","puleos","KennyBu","ragamuf","hlach","whartill","escherrer","TonyRossi","jdpmeng","satwindersingh","zwarm","jasonabi","bootcamp","drewbkilla","hprada") | foreach-object {
  git remote add $_ http://github.com/$_/nbdn_prep.git
}
