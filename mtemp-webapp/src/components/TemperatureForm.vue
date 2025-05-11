<template>
  <div>
    <h3>Record Temperature</h3>

	<div v-if="currentPatient">

		<span>Selected patient: {{currentPatient.getFullName()}}</span> 
		<Button @click="clearSelectedPatient" label="clear" severity="contrast"></Button>
	</div>

    <form @submit.prevent="submitTemperature">
		<label for="temperature">Temperature:</label>
		<input type="number" v-model="temperature" step="0.01" />
		<SelectButton v-model="selectedMeasuredMethod" :options="measurementMethodOptions" />

      	<button type="submit">Submit</button>
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
import {TemperatureMeasurementService} from '../services/TemperatureMeasurementsService';

export default {
	components: {
		SelectButton,
		Button
	},
	setup() {
		TemperatureMeasurementService
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
				TemperatureMeasurementService.addMeasurement(measurement);
			}
		
		}

		return {
			selectedMeasuredMethod,
			measurementMethodOptions,
			temperature,
			currentPatient,
			submitTemperature
		}
	},
	methods: {
		clearSelectedPatient() {
			PatientService.clearSelectedPatient();
		},
		
		
	}
};
</script>
