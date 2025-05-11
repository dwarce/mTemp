<template>
  	<div>
    	<h3>Record Temperature</h3>

		<div v-if="currentPatient" class="current-patient-info">
			<span>Selected patient: <b>{{currentPatient.getFullName()}}</b></span> 
			<div class="buttons">
				<Button @click="clearSelectedPatient" label="Clear selected patient" severity="contrast"></Button>
				<Button @click="showPatientMeasurements" label="Show measurements history" severity="contrast"></Button>
			</div>
		</div>

		<form>
			<label for="temperature">Temperature (°C):</label>
			<input type="number" v-model="temperature" step="0.01" /> 
			<SelectButton v-model="selectedMeasuredMethod" :options="measurementMethodOptions" />
			<Button class="submit-button" label="Submit" @click="submitTemperature"></Button>
		</form>
  	</div>

</template>

<script lang="ts">

import SelectButton from 'primevue/selectbutton';
import Button from 'primevue/button';
import { ref, computed, watch } from 'vue';
import { TemperatureMeasurement } from '../models/TemperatureMeasurement';
import { Patient } from '../models/Patient';
import { PatientService } from '../services/PatientService';
import { NotificationService } from '../services/NotificationService';
import { TemperatureMeasurementsService } from '../services/TemperatureMeasurementsService';

export default {
	components: {
		SelectButton,
		Button
	},
	setup() {
		const selectedMeasuredMethod = ref("Infrared");
		const measurementMethodOptions = ref(["Infrared", "Contact (Axillary)", "Contact (Oral)", "Contact (Rectal)"]);
		const temperature = ref<number | undefined>(undefined);
		const currentPatient = ref<Patient|undefined>(undefined)
		
		const selectedPatientVariable = computed(() => PatientService.selectedPatient.value);

		watch(selectedPatientVariable, (selectedPatient) => {
			currentPatient.value = selectedPatient;
		});

		const checkValidTemperature = (temperature: number | undefined): boolean => {
		
			if (!temperature) {
				NotificationService.showError("Error inserting measuerment", "Temperature must be set")
				return false;
			}
			if (temperature <= 0 && temperature >= 50) {
				NotificationService.showError("Error inserting measuerment", "Temperature must be between 0 and 50 degrees celsius")
				return false;
			}
			return true;
		}

		const submitTemperature = () => {
			if (checkValidTemperature(temperature.value)) {
				const measurement: TemperatureMeasurement = new TemperatureMeasurement(undefined, temperature.value!, selectedMeasuredMethod.value, undefined, currentPatient.value ? currentPatient.value.id : undefined);
				TemperatureMeasurementsService.addMeasurement(measurement);
			}
		}

		const clearSelectedPatient = () => {
			PatientService.clearSelectedPatient();
		}

		const showPatientMeasurements = () => {
			if (currentPatient.value) {
				TemperatureMeasurementsService.getMeasurementsByPatient(currentPatient.value.id!);
			}
		}

		return {
			selectedMeasuredMethod,
			measurementMethodOptions,
			temperature,
			currentPatient,
			submitTemperature,
			clearSelectedPatient,
			showPatientMeasurements
		}
	}

};

</script>
