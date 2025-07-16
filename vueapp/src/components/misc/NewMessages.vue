
<script setup>

	const messageStore = useMessagesStore()
    const { messagesCount,
		clientMaxMessageId,
        serverMaxMessageId } = storeToRefs(messageStore) 
// v-if="messagesCount > 0" 
</script>

<template>
	
	<router-link  
		to="/accounts/messages"
		class="badge-button text-color-blue-gray bg-white hover:opacity-50"
		title="You have new Messages.">
		{{ messagesCount }} Message{{ messagesCount === 1 ? '' : 's'}} 
		{{ clientMaxMessageId }} {{ serverMaxMessageId }}
	</router-link>  

</template>

<!-- USAGE 
	<NewMessages class="self-center" />
-->

