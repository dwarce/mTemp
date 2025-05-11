<template>
  	<div v-if="isMeasurementDetailDialogOpen" class="modal">
    	<div class="popup-content">
      		<h4>Temperature measurement info</h4>
			<li>Temperature: {{ selectedMeasurement?.measuredTemperature }}°C</li>
			<li>Time of measurement: {{ new Date(selectedMeasurement?.timestamp!).toLocaleString() }}</li>
			<li>Method: {{ selectedMeasurement?.measuredMethod }}</li>
			<li v-if="measurementPatient">Patient: {{ measurementPatient.getFullName() }}</li>

      		<button class="submit-button" @click="closePopup">Close</button>
    	</div>
  	</div>
</template>

<script lang="ts">

import { computed, ref, watch  } from 'vue';
import { TemperatureMeasurementsService } from '../services/TemperatureMeasurementsService';
import { PatientService } from '../services/PatientService';
import { Patient } from '../models/Patient';

export default {
	setup() {
		const isMeasurementDetailDialogOpen = computed(() => TemperatureMeasurementsService.isMeasurementDetailDialogOpen.value);
		const selectedMeasurement = computed(() => TemperatureMeasurementsService.selectedMeasurement.value);	
		const measurementPatient = ref<Patient | undefined>(undefined);

		watch(selectedMeasurement, (newVal) => {
			if (newVal && newVal.patientId) {
				measurementPatient.value = PatientService.getLoadedPatientById(newVal.patientId)
			} else {
				measurementPatient.value = undefined;
			}
		});
		
		const closePopup = () => {
			TemperatureMeasurementsService.toggleMeasurementInfoDialog(false);
		};

		return {
			isMeasurementDetailDialogOpen,
			selectedMeasurement,
			measurementPatient,
			closePopup,
		};
	}

}

</script>
