<script setup>

	const props = defineProps({
		show:             Boolean, 
		title:            String,
		teleportToBody:   { type: Boolean, default: true },
		height:           { type: String, default: '300px' },
		width:            { type: String, default: '500px' }
	})

	const emits = defineEmits(["closeModal"])
	emits("closeModal", true);
	
	// document.body.style.overflow = 'hidden'
</script>

<template>
	<Teleport to="body" :disabled="!teleportToBody">    
		<Transition name="modal">

			<div v-if="show" @click.self="$emit('closeModal')"
                class="flex fixed z-[9999] top-0 left-0 w-full h-full bg-black bg-opacity-30
				transition-opacity ease-in-out duration-75">

				<div class="m-auto bg-white rounded-sm shadow-lg shadow-color-dark-gray 
                    max-h-screen max-w-screen transition-all relative" :style="{ height: props.height, width: props.width }">

					<div class="flex justify-between items-center px-5 w-full h-14 text-lg font-bold bg-gradient-modal select-none">
						<slot name="header">
							<span>{{title || 'Title'}}</span>
							<div class="h-7 w-7 bg-white hover:bg-color-light-blue rounded-full flex-center" @click="$emit('closeModal')">
								<IconSymbol width="22px" class="text-color-dark-gray" icon="heroicons-solid:x" />
							</div>
						</slot>
					</div>

					<div class="p-6 overflow-auto">
						<slot>Default body</slot>
					</div>

					<div class=" bg-white p-4 pb-6 absolute bottom-0 w-full flex justify-end gap-2 select-none">
						<slot name="footer">
							<button class="custom-button" @click="$emit('closeModal')">Ok</button>
						</slot>
					</div>

				</div>

			</div>

		</Transition>
	</Teleport> 
</template>

<style lang="postcss" scoped>

    /* The following styles are auto-applied to elements with transition="modal" when their visibility is 
    * toggled by Vue.js. You can easily play with the modal transition by editing these styles. */

	.modal-enter-from { opacity: 0; }
	.modal-leave-to { opacity: 0; }
	.modal-enter-from .modal-container,
	.modal-leave-to .modal-container { -webkit-transform: scale(1.1); transform: scale(1.1); }

</style>