class Git {
  constructor(private name: string, private lastCommitId: number = -1) {}

  commit(message: string) {
    const commit = new Commit(++this.lastCommitId, message);
    return commit;
  }

  log() {
    const history = [];

    return history;
  }
}

class Commit {
  constructor(private id: number, private message: string) {}
}
