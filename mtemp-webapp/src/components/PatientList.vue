<template>
  <div>
    <h3>Patients</h3>
    <Button class="add-patient-button" @click="openAddPatientForm()" label="Add New Patient" severity="contrast"></Button>

    <div class="data-list">
      <Button v-for="patient in patients.slice().reverse()" 
        class="list-button"
        @click="selectPatient(patient)" 
        severity="help"
        :label="`${patient.getFullName()}`"
      >
      </Button>

    </div>
  </div>
</template>

<script lang="ts">
import { PatientService } from '../services/PatientService';
import { Patient } from '../models/Patient'
import { onMounted, computed } from 'vue';
import Button from 'primevue/button';

export default {
  setup() {
    onMounted(() => {
      PatientService.getAllPatients();
    });

    const patients = computed(() => PatientService.patients.value);
    return {
      patients,
    };
  },
  components: {
    Button,
  },
  methods: {
    openAddPatientForm() {
       PatientService.togglePatientDialog(true);
    },
    selectPatient(patient: Patient) {
      PatientService.selectPatient(patient);
    },
  },
  
};
</script>