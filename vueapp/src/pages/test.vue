<script setup>

    const appStore              = useAppStore()
    const { sideBarHidden }     = storeToRefs(appStore)
    const isDirty               = ref(false)

    const { showConfirm }       = useConfirmDialog();

    const handleDelete = async () => 
    {
        const confirmed = await showConfirm('Are you sure you want to delete this item?')

        if (confirmed) 
            console.log('Item deleted!') 
        else 
            console.log('Deletion cancelled.')
    }

</script>

<template>

	<div class="bg-gray h-12 p-3 flex items-center gap-3">
		<PrimaryButton @click="sideBarHidden = !sideBarHidden" title="Show / Hide" />
		<PrimaryButton @click="isDirty = !isDirty" title="Is Dirty?" />
        <div class="text-white">Is Dirty: {{ isDirty }} </div>

        <PrimaryButton @click="handleDelete" title="Delete Something" class="bg-red" />

	</div>

    <SidebarControl :showSideBar="sideBarHidden">

        <template #sidebar>
            <div class="bg-orange w-full h-full p-5">sidebar</div>
        </template>

        <template #default>
            <div class="bg-yellow w-full h-full p-5">default</div>
        </template>

    </SidebarControl>	

</template>