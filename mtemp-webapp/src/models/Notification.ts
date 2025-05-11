export class Notification {
  summary: string;
  detail: string;

  constructor(summary: string = '', detail: string = '') {
    this.summary = summary;
    this.detail = detail;
  }
}