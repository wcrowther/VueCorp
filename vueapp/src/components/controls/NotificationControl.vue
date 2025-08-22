
<script setup>

    const appStore   			= useAppStore()
    const { showNotification }	= storeToRefs(appStore)

</script>

<template>

	<Teleport v-if="showNotification" to="body">
		<div class="fixed left-5 right-5 bottom-5 z-[1000]">
			<div class="relative p-5 main-width bg-white border-2 border-color-light-blue">
				<div class="absolute top-2 right-2" @click="appStore.showNotification = false">
					<div class="h-7 w-7 hover:bg-color-light-blue rounded-full flex-center">
						<IconSymbol width="22px" class="text-color-dark-gray" icon="heroicons-solid:x" />
					</div>
				</div>
				<div class="mr-5">
					<slot>
						This is a one-time notification message. After you dismiss it, it will not show again.
						The state is stored in localStorage which you can toggle on/off in the UserPopout.
					</slot>
				</div>
			</div>
		</div>
	</Teleport>

</template>

<!-- Usage: To show a one-time notification message. Status persisted in localStorage.
	Example:
 
    <NotificationControl />
	<NotificationControl>Custom message here.</NotificationControl>
-->

