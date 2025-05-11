<template>
  <div v-if="isDialogOpen" class="modal">
	<div class="popup-content">
	
		<h4>Measurements History for Patient: {{ selectedPatient?.getFullName() }}</h4>
		
		<div class="data-list">
			<DataTable :value="patientMeasurements.slice().reverse()" class="p-datatable-sm">
				<Column header="Temperature (°C)" field="measuredTemperature"/>
				<Column header="Method" field="measuredMethod"/>
				<Column header="Time">
					<template #body="{ data }">
						{{ data.formatTimestamp() }}
					</template>
				</Column>
			</DataTable>

			<Button @click="closePopup" label="Close" severity="warn"></Button>


		</div>
	
	</div>

  </div>
</template>

<script lang="ts">

import { computed } from 'vue';
import { TemperatureMeasurementsService } from '../services/TemperatureMeasurementsService';
import { PatientService } from '../services/PatientService';
import Button from 'primevue/button';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import { TemperatureMeasurement } from '../models/TemperatureMeasurement';

export default {
	setup() {

		const selectedPatient = computed(() => PatientService.selectedPatient.value);
		const patientMeasurements = computed(() => TemperatureMeasurementsService.selectedPatientMeasurements.value);
		const isDialogOpen = computed(() => TemperatureMeasurementsService.isPatientMeasurementHistoryDialogOpen.value);
		const formatTimestampColumn = (data: TemperatureMeasurement) => data.formatTimestamp();
		
		const closePopup = () => {
			TemperatureMeasurementsService.togglePatientMeasurementHistoryDialog(false);
		};
		return {
			selectedPatient,
			isDialogOpen,
			patientMeasurements,
			formatTimestampColumn,
			closePopup,
		};
	},
	components: {
    	Button,
		Column,
		DataTable,
		
  	}
};
</script>
