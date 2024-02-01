# Quick Katas

A repository for sharing my own attempt at katas, for the sake of my own learning.

Notes deployed to https://tjhleeds.github.io/quick-katas/

## Running Tests

- When using GitHub Codespaces, the tests don't show up by default when you load the Codespace.
- To make them show, type CTRL+SHIFT+P and run `.NET: Rebuild`. This should cause the tests extension to discover the tests.

## Note about PRs

There is a GitHub Action configured to create an index page for the docs folder, which runs when a PR is created/updated. It adds a commit to that PR, so if you want to add further commits to the PR you need to pull that commit first.

If you forget and add a commit, you can follow this process to get rid of the most recent commit, pull changes, then re-add the commit. It won't work for multiple commits.

1. Run these commands to get rid of the commit from the current branch.

    ```bash
    git branch temp_branch
    git reset --hard HEAD^
    ```

1. Pull from the remote
1. Run these commands to get the commit back from the temporary branch.

    ```bash
    git cherry-pick temp_branch
    git branch -D temp_branch
    ```
