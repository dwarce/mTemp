import { ref } from 'vue';
import { TemperatureMeasurement } from '../models/TemperatureMeasurement';
import { NotificationService } from './NotificationService';

export const TemperatureMeasurementService = {

async addMeasurement(measurement: TemperatureMeasurement) {
    const apiUrl = import.meta.env.VITE_API_URL;
    try {
    const response = await fetch(`${apiUrl}/temperatureMeasurement`, {
      method: 'POST',
      headers: {
      'Content-Type': 'application/json'
      },
      body: JSON.stringify(measurement)
    });

    const responseJson = await response.json();
    
    if (!response.ok) {
      NotificationService.showError("Failed to add temperature measurement", responseJson.message);
    } else {
      NotificationService.showSuccess("Measurement added", "");

    }

    } catch (error) {
    console.error("Failed to add patient:", error);
    NotificationService.showError("Failed to add patient", (error as Error).message);
    }
  },

	
	// async addMeasurement(patient: Patient) {
	// 	const apiUrl = import.meta.env.VITE_API_URL;
	// 	try {
	// 	const response = await fetch(`${apiUrl}/patients`, {
	// 		method: 'POST',
	// 		headers: {
	// 		'Content-Type': 'application/json'
	// 		},
	// 		body: JSON.stringify(patient)
	// 	});

	// 	const responseJson = await response.json();
		
	// 	if (!response.ok) {
	// 		NotificationService.showError("Failed to add patient", responseJson.message);
	// 	} else {
	// 		NotificationService.showSuccess("Patient added", `${patient.getFullName()}`);
	// 		this.togglePatientDialog(false);

	// 	}

	// 	} catch (error) {
	// 	console.error("Failed to add patient:", error);
	// 	NotificationService.showError("Failed to add patient", (error as Error).message);
	// 	}
	// },

  // 	async getAllPatients() {
	// 	const apiUrl = import.meta.env.VITE_API_URL;

	// 	try {
	// 	const response = await fetch(`${apiUrl}/patients`, {
	// 		method: 'GET',
	// 		headers: {
	// 		'Content-Type': 'application/json'
	// 		},
	// 	});

	// 	const responseJson = await response.json();
		
		
	// 	if (!response.ok) {
	// 		NotificationService.showError("Failed to get patients", responseJson.message);
	// 	} else {
	// 		const responseJsonArray: any[] = responseJson;			
	// 		this.patients.value = responseJsonArray.map(json => Patient.fromJSON(json));

	// 	}

	// 	} catch (error) {
	// 		console.error("Failed to add patient:", error);
	// 		NotificationService.showError("Failed to add patient", (error as Error).message);
	// 	}  
	// }
};
