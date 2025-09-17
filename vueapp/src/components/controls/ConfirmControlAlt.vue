<script setup>

	const emits = defineEmits(['confirmResponse'])
	const props = defineProps(
	{
		message: 	 { type: String, default: 'Confirm your changes?' },
		confirmText: { type: String, default: 'Confirm' },
		cancelText:  { type: String, default: 'Cancel' }
	})

	const isVisible 		= ref(true)
	const internalMessage 	= ref(props.message)

	// Exposed async confirm function  ====================================

	let resolver = null

	function confirmResponse(msg) 
	{
		if (msg) 
			internalMessage.value = msg

		isVisible.value = true

		return new Promise((resolve) => 
		{
			resolver = resolve
		})
	}

	function onRespond(choice) 
	{
		isVisible.value = false
		emits('confirmResponse', choice) // true = confirm, false = cancel
		resolver?.(choice)
	}

	defineExpose({ confirmResponse })

	// Custom Directive (note casing)

	const vFocus = { mounted: (el) => el.focus() }

	// Keyboard Listeners  ================================================

	DisableLayoutEscapeKey()

	function keys(e) 
	{
		if (e.code === 'Escape') { onRespond(false); e.preventDefault() }
	}

	KeyboardListeners(keys)

</script>


<template>

	<div v-if="isVisible" 
		class="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50 z-[100]">

		<div class="bg-white p-5 pb-7 rounded shadow-md">

			<div class="mb-5 w-full">{{ internalMessage }}</div>
			<div class="flex justify-end gap-3">

				<button @click="onRespond(true)" v-focus @keydown.enter.prevent.stop="onRespond(true)"
					class="btn-primary">{{ props.confirmText }}</button>

				<button @click="onRespond(false)" @keydown.enter.prevent.stop="onRespond(false)" class="btn-delete">{{
					props.cancelText }}</button>
			</div>
		</div>

	</div>
	
</template>
