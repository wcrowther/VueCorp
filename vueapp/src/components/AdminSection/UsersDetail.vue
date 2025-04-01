<script setup>

    const usersStore        = useUsersStore()
    const messageStore      = useMessageStore()
    const 
    { 
        user, 
        detailUserId 
    }                       = storeToRefs(usersStore)
    const 
    { 
        getUserDetailData,
        addNewUser, 
        saveUser
    }                       = usersStore

    const isAddingUser      = ref(false)
    const showConfirmSave   = ref(false)
    const userFullName      = computed(() => user.value.LastName ? `${user.value.FirstName} ${user.value.LastName}` : '---')
    const userTitle         = computed(() => isAddingUser.value ? 'Add new User' : userFullName.value )

    //const rules             = computed(() => userValidator)

	const v$ = useVuelidate(userValidator, user) // validator

    const getUserDetail = async () =>
    {
        if(detailUserId.value === 0)
            return

        isAddingUser.value   = false

        getUserDetailData(detailUserId.value)
    }

    const addUser = () =>
    {
       isAddingUser.value = true 
       addNewUser()
    }

    const cancelAdd = () =>
    {
       isAddingUser.value = false 
       v$.value.$reset()
       getUserDetail()
    }

    const confirmDelete = () => alert('Delete not yet implemented.')
    const confirmSave = async () =>
    {
        const isValidUser = await v$.value.$validate()

        if(isValidUser)
        {
            showConfirmSave.value = true
        }
        else
        {
            let message = 'Cannot save as user is not valid.'
            messageStore.showError(message) 
        }    
    }

    const saveUserDetail = async () =>
    {        
        saveUser()
        isAddingUser.value = false 
        showConfirmSave.value = false
        v$.value.$reset()
    }

    const cancelAction = () => 
    {
        showConfirmSave.value = false
        v$.value.$reset()
        // getUserDetail()
    }

    // Listeners   =============================================================================

    const keys = function (e)   
    {
        let ctrl = navigator.userAgentData.platform.match("Mac") ? e.metaKey : e.ctrlKey   
        if (e.code === 'KeyS' && ctrl) { confirmSave();  e.preventDefault(); }
    }

	KeyboardListeners(keys);

    // Lifecycle & Watches  ==========================================================================

    onMounted(()    => 
    {
        getUserDetail()

    })

    watch(() => detailUserId.value, (newVal, oldVal) => 
    {
        // console.log('User userId newval: ' + newVal + ' oldVal: ' + oldVal)

        if(newVal === oldVal) 
            return

        getUserDetail()  
    });

    // ===============================================================================================

</script>

<template>

    <div class="flex flex-wrap gap-5" id="UsersDetailView">

        <ConfirmDialog v-if="showConfirmSave" message="Save User Data?" 
			@confirm="saveUserDetail" @cancel="cancelAction" />

        <div class="w-full flex justify-between items-center">

            <h2 class="text-2xl font-display font-bold flex-grow">{{ userTitle }}</h2>

            <span class="flex flex-wrap gap-3"> 

                <div class="">
                    <IconSymbol v-if="!isAddingUser" width="28px" @click="addUser" title="Add User"
                        class="icon-symbol" icon="heroicons:plus-circle-16-solid" />
                    <IconSymbol v-else width="28px" @click="cancelAdd" title="Cancel"
                        class="icon-symbol" icon="heroicons:x-circle-16-solid" />
                </div>
                                
                <template v-if="isAddingUser || hasKeys(user) && user.UserId > 0">
                    <IconSymbol width="22px" @click="confirmSave" title="Save User"
                        class="icon-symbol mt-[2px]" icon="fa-solid:save" />
                    <IconSymbol width="28px"  @click="confirmDelete" title="Delete User"
                        class="icon-symbol -ml-[4px]" icon="heroicons:trash-16-solid" />
                </template>

            </span>

        </div>

        <div v-if="(!user || user.UserId === 0)  && !isAddingUser" class="w-[300px] font-bold">
            No User to display
        </div>

        <div v-if="user && user.UserId > 0 || isAddingUser"  
             class="w-[300px] flex-1 border border-color-blue-gray bg-white">

            <div class="p-5 min-w-[200px] relative grow linear-gray">

                <TitleBox v-if="!isAddingUser">
                    <span class="text-color-dark-blue font-bold whitespace-nowrap text-l">
                        UserName: {{user.UserName}}
                    </span>
                    <span class="text-color-dark-blue font-bold whitespace-nowrap text-l">
                        UserId: {{user.UserId}}
                    </span>
                </TitleBox>

                <MetaBox v-if="!isAddingUser">
                    <span title="Modified: 2/24/2025 7:23:23">Modified: 2/24/2025 by wcrowther</span>
                    <span title="Created: 1/22/2024 13:44:33">Created: 1/22/2024 by wcrowther</span>
                </MetaBox>

                <template v-if="isAddingUser">
                    <TextInput labelName="UserName"     v-model="user.UserName"     :v$ />                
                    <TextInput labelName="UserPassword" v-model="user.UserPassword" :v$ />                
                </template>

                <TextInput labelName="First Name" v-model="user.FirstName" :v$ />
                <TextInput labelName="Last Name"  v-model="user.LastName"  :v$ />
                <TextInput labelName="UserEmail"  v-model="user.UserEmail" :v$ />
                <SelectInput labelName="Role"  v-model="user.Role" :v$ :optionsList="roleList" />

            </div>
        </div>

    </div>

</template>

<style lang="postcss" scoped>
	.icon-symbol {
        @apply text-color-mid-blue hover:text-white
    }    
</style>