import { ref } from 'vue';
import { Notification } from '../models/Notification';

export const NotificationService = {

  currentSuccessNotification: ref<Notification[]>([]),
  currentInfoNotification: ref<Notification[]>([]),
  currentWarningNotification: ref<Notification[]>([]),
  currentErrorNotification: ref<Notification[]>([]),

  showSuccess(summary: string, detail: string) {
    this.currentSuccessNotification.value = [...this.currentSuccessNotification.value, new Notification(summary, detail)];
  },
  showInfo(summary: string, detail: string) {   
    this.currentInfoNotification.value = [...this.currentInfoNotification.value, new Notification(summary, detail)];
  },
  showWarning(summary: string, detail: string) {
    this.currentWarningNotification.value = [...this.currentWarningNotification.value, new Notification(summary, detail)];

  },
  showError(summary: string, detail: string) {
    this.currentErrorNotification.value = [...this.currentErrorNotification.value, new Notification(summary, detail)];
  }

};
