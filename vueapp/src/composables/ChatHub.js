import { ref, onUnmounted } from 'vue'
import * as signalR from '@microsoft/signalr'

export function useChatHub() 
{
    const appStore     	    = useAppStore()
    const messageStore	    = useMessageStore()

    const { newMessage, 
            messages }      = storeToRefs(messageStore) 

    const { getAllMessages } = messageStore

    const isConnected   = ref(false)      
    
    const connection    =  new signalR.HubConnectionBuilder()
                            .withUrl(`${appStore.baseApiUrl}/chathub`)
                            .withAutomaticReconnect()
                            .build()

    const startChat = async () => 
    {
        try 
        {
            await getAllMessages()

            connection.on('ReceiveMessage', (userName, userId, message) => 
            {
                messages.value.push({ userName, userId, text: message })
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

    const sendMessage = async (firstName, userId) => 
    {
        // Add error checking etc here
        if (isConnected.value && firstName && userId && newMessage.value) 
        {
            await connection.invoke('SendMessage', firstName, userId, newMessage.value)
            newMessage.value = ''
        }
    }

    onMounted(startChat)
    onUnmounted(() =>  { connection.stop() })

    return {
        isConnected,
        sendMessage,
        startChat,
    }
}
