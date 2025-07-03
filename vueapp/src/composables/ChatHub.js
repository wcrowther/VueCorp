import { ref, onUnmounted } from 'vue'
import * as signalR from '@microsoft/signalr'

export function useChatHub() 
{
    const appStore     	= useAppStore()
    
    const connection = new signalR.HubConnectionBuilder()
        .withUrl(`${appStore.baseApiUrl}/chathub`)
        .withAutomaticReconnect()
        .build()

    const messages = ref([])
    const isConnected = ref(false)

    const startChat = async () => 
    {
        try 
        {
            // TODO: Get messages from the MessageStore 
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

    const sendMessage = async (firstName, userId, message) => 
    {
        // Add error checking etc here
        if (isConnected.value && firstName && userId && message) 
        {
            // Send message to the messageStore to save

            await connection.invoke('SendMessage', firstName, userId, message)
        }
    }

    onMounted(startChat)
    onUnmounted(() =>  { connection.stop() })

    return {
        messages,
        isConnected,
        sendMessage,
        startChat,
    }
}
