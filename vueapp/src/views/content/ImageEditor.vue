<script setup>

    // const listPager     = defineModel('listPager')
    const showModal          = defineModel('showModal')

    // const emits         = defineEmits(["getListData"])
    // const getListData   = () => emits('getListData')

    // Keyboard Listeners  ================================================
	
	DisableLayoutEscapeKey()

    const keys = function (e)   
    {
		if (e.code === 'Escape'){ showModal.value=false; e.preventDefault(); } 
    }

	KeyboardListeners(keys)

</script> 

<template>   

	<ModalControl :showModal="showModal" title="ImageEditor" id="ImageEditor" 
        height="90%" width="90%" class="p-6 pb-10 overflow-hidden" @closeModal="showModal=false">

        <!-- overflow-y-auto scrollbar-thin -->
        <TabControl class="h-full" contentClass="p-5" 
            id="ImageEditorTabControl" 
            :tabList="['Gallery', 'Detail', 'Upload']" >

            <template #Gallery>       
                <ImageGallery />
            </template>
            
            <template #Detail>       
                <ImageDetail />
            </template>
            
            <template #Upload>       
                <ImageUpload />
            </template>

        </TabControl>

        <template #footer>
            <button class="btn-delete" @click="showModal=false">Close</button>
        </template> 

	</ModalControl>

</template>

