# Quick Katas

A repository for sharing my own attempt at katas, for the sake of my own learning.

## Note about PRs

There is a Github Action configured to create an index page for the docs folder, which runs when a PR is created/updated. It adds a commit to that PR, so if you want to add further commits to the PR you need to pull that commit first.

If you forget and add a commit, you can follow this process to get rid of the most recent commit, pull changes, then re-add the commit. It won't work for multiple commits.

```bash
git branch temp_branch
git reset --hard HEAD^
```

Pull from the remote

```bash
git cherry-pick temp_branch
git branch -D temp_branch
```
