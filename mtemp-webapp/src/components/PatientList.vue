<template>
  <div>
    <h3>Patients</h3>
    <button @click="openAddPatientForm()">Add New Patient</button>
    <ul>
      <li v-for="patient in patients" :key="patient.id">
        <button @click="selectPatient(patient)">
          {{ patient.getFullName() }}
        </button>
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { PatientService } from '../services/PatientService';
import { Patient } from '../models/Patient'
import { onMounted, computed } from 'vue';

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