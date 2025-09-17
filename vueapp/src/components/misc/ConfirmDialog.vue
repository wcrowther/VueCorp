<!-- Alternate to ConfirmControl.vue - uses Promise instead of Events -->	

<script setup>

	const isVisible = ref(false);
	const message 	= ref('Confirm your changes?');

	let resolvePromise; // Function to resolve the promise

	const showDialog = (msg) => 
	{
		message.value = msg
		isVisible.value = true
		return new Promise((resolve) => 
		{
			resolvePromise = resolve
		});
	}

	defineExpose({ showDialog });

	const onConfirm = () => 
	{
		isVisible.value = false;
		resolvePromise(true);
	};

	const onCancel = () => 
	{
		isVisible.value = false;
		resolvePromise(false);
	};

	// Keyboard Listeners  ================================================
	
	DisableLayoutEscapeKey()

    const keys = function (e)   
    {
		if (e.code === 'Escape'){ onCancel(); e.preventDefault(); } 
    }

	KeyboardListeners(keys)

</script>

<template>

	<teleport to="body">

		<div v-if="isVisible" 
			class="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50 z-[100]">
		
			<div class="bg-white p-5 pb-7 rounded shadow-md">

				<div class="mb-5 w-full">{{ message }}</div>
				<div class="flex justify-end gap-3">

					<button @click="onConfirm" @keydown.enter.prevent.stop="onConfirm"  
						class="btn-primary">Confirm</button>

					<button @click="onCancel" @keydown.enter.prevent.stop="onCancel"  
						class="btn-delete">Cancel</button>

				</div>
			</div>
		</div>

	</teleport>
	
</template>