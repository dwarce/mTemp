export class Patient {
  id: number | undefined;
  firstName: string;
  lastName: string;
  email: string;

  constructor(id: number | undefined = undefined, firstName: string = '', lastName: string = '', email: string = '') {
    this.id = id;
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
  }

  static fromJSON(json: any): Patient {
    return new Patient(json.id, json.firstName, json.lastName, json.email);
  }

  getFullName() {
    return `${this.firstName} ${this.lastName}`;
  }
}