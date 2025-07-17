

<script setup>

	const { startChat, messages, message, sendMessage } = useChatHub()  

	const messageStore 				= useMessagesStore()
    const { serverMaxMessageId } 	= storeToRefs(messageStore) 

	const authStore	   				= useAuthStore()
	const { userId:currentUserId }	= storeToRefs(authStore)  

	const latestFirst 				= ref(useLocalStorage('chatRoomLatestFirst', true))  
	const isCurrentUser				= (userId) =>  userId === currentUserId.value  

	// ====================================================================
	
	onMounted ( startChat )

</script>

<template>
	<div class="bg-white border border-blue flex flex-wrap w-full">

		<div class="p-4 w-full md:w-1/2 lg:w-1/4 bg-color-light-blue/50">
			<TextInput v-model.trim="message.MessageText" 
				@keydown.enter.prevent.stop="sendMessage"  
				placeholder="Message" labelName="Message" />

			<TextInput v-model.trim="serverMaxMessageId" labelName="MaxId" />
			<PrimaryButton title="Send" @click="sendMessage" />
		</div>

		<div class="p-4 w-full md:w-1/2 lg:w-3/4">

			<div class="pb-3 mb-3 font-bold border-b border-blue flex justify-between items-center">
				<span class="">Chat Messages</span>
				<span class="ml-auto badge-button cursor-pointer text-white bg-color-primary hover:bg-orange" 
					@click="latestFirst = !latestFirst" title="Toggle message sort order">
					{{ latestFirst ? 'Latest First' : 'Oldest First' }}
				</span>  
			</div>
			<div :class="['flex pr-4 max-h-[400px] overflow-y-auto scrollbar-thin', 
				(latestFirst ? 'flex-col-reverse' : 'flex-col')]">
				<template v-for="(msg, index) in messages" :key="index">

					<div v-if="isCurrentUser(msg.CreatorId)"
						class="px-4 py-2 mb-2 mr-9 border border-[#b8d7ed] rounded-lg w-fit min-w-[75%]"
						:title="dateTimeFormat(msg.DateCreated)">
						{{ msg.MessageText }}
					</div>

					<div v-else class="px-4 py-2 mb-2 ml-auto border border-color-mid-blue
						text-color-dark-blue rounded-lg w-fit min-w-[75%]"
						:title="dateTimeFormat(msg.DateCreated)">
						<span class="font-bold text-color-mid-blue">{{ msg.CreatorName }} : </span>
						{{ msg.MessageText }}
					</div>
					
				</template>
			</div>

			<div v-if="messages.length === 0" class="">
				No messages to display.
			</div>

		</div>

	</div>
</template>