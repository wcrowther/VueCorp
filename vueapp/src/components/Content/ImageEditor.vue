<script setup>

    // const listPager     = defineModel('listPager')
    const show          = defineModel('show')

    // const emits         = defineEmits(["getListData"])
    // const getListData   = () => emits('getListData')

</script> 

<template>   

	<ModalControl :show="show" title="ImageEditor" id="ImageEditor" 
        height="90%" width="90%" class="p-6 pb-10" @closeModal="show=false">

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
            <button class="btn-delete" @click="show=false">Close</button>
        </template> 

	</ModalControl>

</template>

