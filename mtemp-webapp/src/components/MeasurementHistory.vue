<template>
  <div>
    <h3>Measurements History</h3>

	<div class="data-list">
		<Button v-for="measurement in allMeasurements.slice().reverse()"
			class="list-button"
			@click="viewMeasurement(measurement)"   
			severity="info"
			:label="`${measurement.measuredTemperature}°C - ${new Date(measurement.timestamp!).toLocaleString()}`"
		>
		</button>
	</div>

  </div>
</template>

<script lang="ts">

import { onMounted, computed } from 'vue';
import { TemperatureMeasurementsService } from '../services/TemperatureMeasurementsService';
import { TemperatureMeasurement } from '../models/TemperatureMeasurement';
import Button from 'primevue/button';

export default {
	setup() {
		onMounted(() => {
			TemperatureMeasurementsService.getAllMeasurements();
		});

		const allMeasurements = computed(() => TemperatureMeasurementsService.allMeasurements.value);

		return {
			allMeasurements,
		};
	},
	components: {
    	Button,
  	},
	methods: {
		viewMeasurement(measurement: TemperatureMeasurement) {
			TemperatureMeasurementsService.showMeasurementInfo(measurement);			
		}
  	}
};
</script>
