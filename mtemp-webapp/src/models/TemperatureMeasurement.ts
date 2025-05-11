export class TemperatureMeasurement {
    id: number | undefined;
    measuredTemperature: number;
    measuredMethod: string;
    timestamp: number | undefined;
    patientId: number | undefined;


  constructor(id: number | undefined = undefined, measuredTemperature: number, measuredMethod: string, timestamp: number | undefined = undefined, patientId: number | undefined = undefined) {
    this.id = id;
    this.measuredTemperature = measuredTemperature;
    this.measuredMethod = measuredMethod;
    this.timestamp = timestamp;
    this.patientId = patientId;
  }

  static fromJSON(json: any): TemperatureMeasurement {
    return new TemperatureMeasurement(json.id, json.measuredTemperature, json.measuredMethod, json.timestamp, json.patientId);
  }


}