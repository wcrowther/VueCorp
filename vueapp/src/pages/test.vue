<script setup>

    //const appStore              = useAppStore()
    //const { sideBarHidden }     = storeToRefs(appStore)
    const isDirty               = ref(false)

    const { fnShowConfirm }      = useConfirmDialog();
    
    const handleSave = async () => 
    {
        if (!isDirty.value) // only confirm if there are unsaved changes
        {
            console.log('Nothing to save!') 
            return
        }   
        
        const confirmed = await fnShowConfirm('Are you sure you want to save this item?')
    
        if (confirmed) 
            console.log('Item saved!') 
        else 
            console.log('Save cancelled.')
     }

    // Use ConfirmControl composable (not ConfirmDialog component)
    // import useConfirmControl from '@/composables/useConfirmControl.js'
    // const { confirm, showConfirm, confirmMessage, onConfirm, onCancel } = useConfirmControl()

    useUnsavedChangesGuard(isDirty, fnShowConfirm, false)

</script>

<template>
	<LayoutMain>
        <div class="bg-gray h-12 p-3 flex items-center gap-3">

            <!-- <PrimaryButton @click="sideBarHidden = !sideBarHidden" title="Show / Hide" /> -->

            <PrimaryButton @click="isDirty = !isDirty"> Is Dirty? {{ isDirty }}</PrimaryButton>   

            <PrimaryButton @click="handleSave" title="Save Something" class="bg-red" /> 

            <!-- <ConfirmControl v-if="showConfirm" :message="confirmMessage"  @confirmResult="onConfirm"  /> -->
        </div>


        <SidebarStaticControl>

            <template #sidebar>
                <div class="bg-orange w-full flex-1 p-5">sidebar</div>
            </template>

            <template #default>
                <div class="bg-yellow w-full flex-1 p-5">default</div>
            </template>

        </SidebarStaticControl>	 

    </LayoutMain>

</template>