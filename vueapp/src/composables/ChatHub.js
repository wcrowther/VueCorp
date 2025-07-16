import * as signalR         from '@microsoft/signalr'

export function useChatHub() 
{
    const authStore	= useAuthStore()
    const { userId: currentUserId } = storeToRefs(authStore) 

    const messageStore = useMessagesStore()
    const { message, messages, serverMaxMessageId }      = storeToRefs(messageStore) 
    const { addNewMessage, getAllMessages, saveMessage } = messageStore

    const appStore      = useAppStore()

    const isConnected   = ref(false)  
    const connection    = new signalR.HubConnectionBuilder()
                            .withUrl(`${appStore.baseApiUrl}/chathub`)
                            .withAutomaticReconnect()
                            .build()

    const startChat = async () => 
    {
        try 
        {
            addNewMessage(currentUserId, '')

            await getAllMessages()  // get messages from server

            connection.on('ReceiveMessage', message => 
            {
                messages.value.push(message)
                serverMaxMessageId.value = message.MessageId
            })

            connection.on('ReceiveMaxMessageId', (serverMaxId) => 
            {
                serverMaxMessageId.value = serverMaxId
            })

            await connection.start()

            isConnected.value = true

            console.log('SignalR connected')
        } 
        catch (error) 
        {
            console.error('SignalR connection failed:', error)
        }
    }

    const sendMessage = async () => 
    {
        var messageSaved = await saveMessage(message.value)

        // ====================================================================
        // Alt version calling ChatHub.SendMessage using this code. Currently we 
        // are calling to all the chathubs on the server in c# MessageEndpoints
        // ====================================================================
        // if(!messageSaved)
        // {
        //     console.error('Not able to save message.')
        //     return
        // }
        // await connection.invoke('SendMessage', messageSaved)
        // ====================================================================

        console.log('ChatHub.sendMessage()', messageSaved.CreatorId, messageSaved.MessageText)

        message.value = addNewMessage(currentUserId, '')  // reset message
    }

    onUnmounted(() =>  { connection.stop() })

    return {
        isConnected,
        sendMessage,
        startChat,
        message,
        messages
    }
}
