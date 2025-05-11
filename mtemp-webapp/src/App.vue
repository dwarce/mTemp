<template>
  <div class="app">
    <div class="main-container">
      <div class="left-panel">
        <PatientList />
      </div>

      <div class="center-panel">

        <h1>mTEMP</h1>

        <TemperatureForm  />
      </div>

      <div class="right-panel">
        <MeasurementHistory/>
      </div>
    </div>

    <AddPatientPopup />

    <MeasurementDetailsPopup />

    <PatientMeasurementHistoryPopup />

    <Toast position="bottom-center"/>
  </div>

</template>

<script lang="ts">
import PatientList from './components/PatientList.vue';
import TemperatureForm from './components/TemperatureForm.vue';
import MeasurementHistory from './components/MeasurementHistory.vue';
import AddPatientPopup from './components/AddPatientPopup.vue';
import MeasurementDetailsPopup from './components/MeasurementDetailsPopup.vue';
import PatientMeasurementHistoryPopup from './components/PatientMeasurementsHistoryPopup.vue';
import { NotificationService } from './services/NotificationService';
import { Notification } from './models/Notification'
import { useToast } from "primevue/usetoast";
import { computed, ref, watch  } from 'vue';
import Toast from 'primevue/toast';  // Import Toast



export default {
  setup() {
        const toast = useToast();
        const successNotification = computed(() => NotificationService.currentSuccessNotification.value);
        const infoNotification = computed(() => NotificationService.currentInfoNotification.value);
        const warningNotification = computed(() => NotificationService.currentWarningNotification.value);
        const errorNotification = computed(() => NotificationService.currentErrorNotification.value);
        watch(successNotification, (newVal) => {          
          	if (newVal && newVal[0]) {
              const notification: Notification = newVal[0];
              toast.add({ severity: 'success', summary: notification.summary, detail: notification.detail, life: 5000 });
          	}
        });

		    watch(infoNotification, (newVal) => {     
          	if (newVal && newVal[0]) {
              const notification: Notification = newVal[0];
              toast.add({ severity: 'info', summary: notification.summary, detail: notification.detail, life: 5000 });
          	}
        });

        watch(warningNotification, (newVal) => {
            if (newVal && newVal[0]) {
              const notification: Notification = newVal[0];
              toast.add({ severity: 'warn', summary: notification.summary, detail: notification.detail, life: 5000 });
            }
          });

        watch(errorNotification, (newVal) => {
            if (newVal && newVal[0]) {
              const notification: Notification = newVal[0];
              toast.add({ severity: 'error', summary: notification.summary, detail: notification.detail, life: 5000 });
            }
        });
  },
  components: {
    PatientList,
    TemperatureForm,
    MeasurementHistory,
    AddPatientPopup,
    MeasurementDetailsPopup,
    PatientMeasurementHistoryPopup,
    Toast,
  }
};
</script>

<style scoped>
.app {
  display: flex;
  justify-content: space-between;
  gap: 2rem;
}

.main-container {
  display: grid;
  grid-template-columns: 1fr 2fr 1fr; /* 3 columns layout */
  gap: 2rem;
  width: 100%;
}

.left-panel, .center-panel, .right-panel {
  padding: 1rem;
  border: 1px solid #ccc;
  border-radius: 8px;
  display: flex;
  flex-direction: column;
}

.left-panel {
  max-height: 80vh;
  overflow-y: auto;
}

.center-panel {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.right-panel {
  max-height: 80vh;
  overflow-y: auto;
}

/* Popup styling */


</style>
