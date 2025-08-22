
<script setup>

	const { messagesCount, 
			monitorChat,
			clientMaxMessageId, 
			serverMaxMessageId } = useChatHub()  

	onMounted(() => 
	{
        monitorChat()
		console.log('NewChatMessages onMounted')
    })

	// THIS COMPONENT IS NOT YET COMPLETED AND IS STILL IN PROGRESS

</script>

<template>

	<!--  v-if="messagesCount > 0"  -->
	<router-link  
		to="/accounts/messages"
		class="badge-button text-color-blue-gray bg-white hover:opacity-50"
		title="You have new Messages">
		{{ messagesCount }} Message{{ messagesCount === 1 ? '' : 's'}} 
		{{ clientMaxMessageId }} {{ serverMaxMessageId }}
	</router-link>  

</template>

<!-- USAGE 
	<NewChatMessages class="self-center" />
-->

