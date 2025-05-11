<template>
  <div>
    <h3>Measurement History</h3>
    <ul>
      <li v-for="measurement in measurements" :key="measurement.date">
        <!-- <button @click="viewMeasurement(measurement)">
          {{ measurement.date }}: {{ measurement.temperature }} °C
        </button> -->
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
export default {
  props: ['measurements'],
  methods: {
   
  }
};
</script>
