<script setup>
import { computed } from 'vue'

const props = defineProps({
  type: {
    type: String,
    default: 'button',
  },
  label: {
    type: String,
    required: true,
  },
  color: {
    type: String,
    default: 'emerald',
  },
  customClass: {
    type: String,
    default: '',
  },
})

const emit = defineEmits(['click'])

const colorMap = {
  emerald: 'bg-emerald-400 text-white hover:bg-emerald-500',
  red: 'bg-red-400 text-white hover:bg-red-500',
  slate: 'bg-slate-500 text-white hover:bg-slate-600',
  white: 'border border-slate-300 bg-white text-slate-700 hover:bg-slate-50',
}

const buttonClass = computed(() => {
  const baseClasses = 'rounded-lg px-6 py-3 font-bold cursor-pointer transition-colors'
  const selectedColor = colorMap[props.color] || colorMap.emerald

  return `${baseClasses} ${selectedColor} ${props.customClass}`.trim()
})
</script>

<template>
  <button :type="type" :class="buttonClass" @click="emit('click')">
    {{ label }}
  </button>
</template>
