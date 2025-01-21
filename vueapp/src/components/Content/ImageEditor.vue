<script setup>

    // const listPager     = defineModel('listPager')
    const show          = defineModel('show')

    // const emits         = defineEmits(["getListData"])
    // const getListData   = () => emits('getListData')

</script> 

<template>   

	<ModalControl :show="show" title="Image Editor" id="Image Editor" 
        height="90%" width="90%" class=""
        @closeModal="show=false">

        <TabControl class="h-full" 
            title="" :tabList="['Gallery', 'Detail', 'Upload']" >

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
            <button class="btn-delete"   @click="show=false">Close</button>
        </template> 

	</ModalControl>

</template>

