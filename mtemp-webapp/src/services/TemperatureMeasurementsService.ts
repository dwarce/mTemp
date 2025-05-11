import { ref } from 'vue';
import { TemperatureMeasurement } from '../models/TemperatureMeasurement';
import { NotificationService } from './NotificationService';

export const TemperatureMeasurementsService = {
  	allMeasurements: ref<TemperatureMeasurement[]>([]), 
	selectedMeasurement: ref<TemperatureMeasurement | undefined>(undefined),
	
	isMeasurementDetailDialogOpen: ref(false),

	toggleMeasurementInfoDialog(status: boolean) {
		this.isMeasurementDetailDialogOpen.value = status;
	},

	showMeasurementInfo(measurement: TemperatureMeasurement) {
		this.selectedMeasurement.value = measurement;
		this.isMeasurementDetailDialogOpen.value = true;

	},

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
				this.getAllMeasurements();
			}

		} catch (error) {
			console.error("Failed to add patient:", error);
			NotificationService.showError("Failed to add patient", (error as Error).message);
		}
	},

	
    async getAllMeasurements() {
      const apiUrl = import.meta.env.VITE_API_URL;

      try {
      const response = await fetch(`${apiUrl}/temperatureMeasurement`, {
        method: 'GET',
        headers: {
        'Content-Type': 'application/json'
        },
      });

      const responseJson = await response.json();
      
      
      if (!response.ok) {
        NotificationService.showError("Failed to get temperature measurements", responseJson.message);
      } else {
        const responseJsonArray: any[] = responseJson;			
        this.allMeasurements.value = responseJsonArray.map(json => TemperatureMeasurement.fromJSON(json));

      }

      } catch (error) {
        console.error("Failed to add patient:", error);
        NotificationService.showError("Failed to add patient", (error as Error).message);
      }  
    }
};
