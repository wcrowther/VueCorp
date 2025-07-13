import * as signalR         from '@microsoft/signalr'

export function useChatHub() 
{
    const appStore                  = useAppStore()
    const messageStore              = useMessagesStore()
    const authStore	                = useAuthStore()

    const { userId: currentUserId } = storeToRefs(authStore)  
    
    const { message, 
            messages }              = storeToRefs(messageStore) 

    const { addNewMessage,
            getAllMessages,
            saveMessage }           = messageStore

    const isConnected               = ref(false)  
    const connection                =  new signalR.HubConnectionBuilder()
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

        // if(!messageSaved.value)
        // {
        //     console.error('Not able to save message.')
        //     return
        // }

        console.log('ChatHub.sendMessage()', message.value.UserId, message.value.MessageText)

        await connection.invoke('SendMessage', message.value)

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
