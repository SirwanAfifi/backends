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
    const history = [];

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
