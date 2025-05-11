<template>

    <div v-if="isPatientDialogOpen" class="modal">

		<div class="popup-content">
			
			<h4>Add New Patient</h4>

			<form @submit.prevent="submit">
				<input v-model="newPatient.firstName" placeholder="Patient first name" required />
				<input v-model="newPatient.lastName" placeholder="Patient last name" required />
				<input v-model="newPatient.email" placeholder="Patient email" required />
				<button class="add-patient-button" type="submit">Add Patient</button>
			</form>

			<Button @click="closeForm" label="Cancel" severity="warn"></Button>
		</div>
    </div>
</template>

<script lang="ts">

import { computed, ref, watch  } from 'vue';
import { PatientService } from '../services/PatientService';
import { Patient } from '../models/Patient';
import { NotificationService } from '../services/NotificationService';
import Button from 'primevue/button';



export default {
	setup() {
		const isPatientDialogOpen = computed(() => PatientService.isNewPatientDialogOpen.value);
		const newPatient = ref<Patient>(new Patient());

		watch(isPatientDialogOpen, (newVal) => {
			if (newVal) {
				initiateNewPatient();
			}
		});

		const submit = (): void => {
			if (checkValidPatientData(newPatient.value)) {		
				PatientService.addPatient(newPatient.value);
			}
		};

		const initiateNewPatient = (): void => {
			newPatient.value = new Patient();
		}

		const checkValidPatientData = (patient: Patient): boolean => {
			
			if (!(patient.firstName && patient.firstName.length)) {
				NotificationService.showError("Error inserting patient", "First name cannot be empty");
				return false;
			}
			if (!(patient.lastName && patient.lastName.length)) {
				NotificationService.showError("Error inserting patient", "Last name cannot be empty");
				return false;
			}
			if (!(patient.email && patient.email.length)) {
				NotificationService.showError("Error inserting patient", "Email cannot be empty");
				return false;
			}
			return true;
		}

		const closeForm = () => {
			PatientService.togglePatientDialog(false);
		};

		return {
			isPatientDialogOpen,
			newPatient,
			submit,
			closeForm,
		};
	},
	components: {
		Button,
	}
};
</script>
