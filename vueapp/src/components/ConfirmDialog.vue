
<script setup>

	const emits = defineEmits(['confirm', 'cancel'])
	const props = defineProps(
	{
		isVisible: Boolean,
		message: 	 { type: String, default: 'Confirm your changes?' }, 
		confirmText: { type: String, default: 'Confirm' }, 
		cancelText:  { type: String, default: 'Cancel' } 
	});

    const onConfirm     = () => emits('confirm')
	const onCancel      = () => emits('cancel')

    // Custom Directive (note casing)
    const vFocus = {
        mounted: (el) => el.focus()
    }

</script>

<template>

	<div v-if="isVisible" 
        class="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50 z-[100]">

		<div class="bg-white p-5 pb-7 rounded shadow-md">
			<div class="mb-5 w-full">{{ message }}</div>
			<div class="flex justify-end gap-3">
				<button @click="onConfirm" v-focus @keydown.enter.prevent.stop="onConfirm"  
                    class="btn-primary">{{props.confirmText}}</button>
				<button @click="onCancel" @keydown.enter.prevent.stop="onCancel"  
                    class="btn-delete">{{props.cancelText}}</button>
			</div>
		</div>
	</div>

</template>