class Git {
  private lastCommitId: number = -1;
  private HEAD = null;
  constructor(private name: string) {}

  commit(message: string) {
    const commit = new Commit(++this.lastCommitId, this.HEAD, message);

    this.HEAD = commit;
    return commit;
  }

  log() {
    let commit = this.HEAD,
      history = [];

    while (commit) {
      history.push(commit);
      commit = commit.parent;
    }

    return history;
  }
}

class Commit {
  constructor(
    private id: number,
    private parent: string,
    private message: string
  ) {}
}
