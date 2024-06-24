<script setup>

    const usersStore           = useUsersStore()
    const messageStore         = useMessageStore()
    const 
    { 
        user, 
        detailUserId 
    }                           = storeToRefs(usersStore)
    const 
    { 
        getUserDetailData,
        addNewUser, 
        saveUser
    }                           = usersStore

    const isAddingUser          = ref(false)
    const isConfirmVisible      = ref(false)
    const userFullName          = computed(() => user.value.LastName ? `${user.value.FirstName} ${user.value.LastName}` : '---')
	const rules                 = computed(() => userValidator)
    const userTitle             = computed(() => isAddingUser.value ? 'Add new User' : userFullName.value )

	const v$ = useVuelidate(rules, user) // validator

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

    const confirmSave = async () =>
    {
        const isValidUser = await v$.value.$validate()

        if(isValidUser)
        {
             isConfirmVisible.value = true
        }
        else
        {
            let message = 'Cannot save as user is not valid.'
            messageStore.showError(message) 
            console.log(message)
        }    
    }

    const saveUserDetail = async () =>
    {        
        saveUser()
        isAddingUser.value = false 
        isConfirmVisible.value = false
        v$.value.$reset()
    }

    const cancelAction = () => 
    {
        isConfirmVisible.value = false
        v$.value.$reset()
        // getUserDetail()
    }

    // Listeners   =============================================================================

    const keys = function (e)   
    {
        // console.log('ctrlKey: ' + e.ctrlKey + ' code: ' + e.code );   

        let ctrl = navigator.userAgentData.platform.match("Mac") ? e.metaKey : e.ctrlKey   
        if (e.code === 'KeyS' && ctrl) { confirmSave();  e.preventDefault(); }
    }

    const addKeyListeners       = () => document.addEventListener('keydown', keys, false)
    const removeKeyListeners    = () => document.removeEventListener('keydown', keys, false)

    // Lifecycle & Watches  ==========================================================================

    onMounted(()    => 
    {
        getUserDetail()
        addKeyListeners()
    })

    onUnmounted(() => 
    { 
        removeKeyListeners() 
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
 
        <ConfirmDialog :isVisible="isConfirmVisible"
			message="Save User Data?" @confirm="saveUserDetail" @cancel="cancelAction" />

        <div class="w-full flex justify-between items-center">

            <h2 class="text-2xl font-display font-bold flex-grow">{{ userTitle }}</h2>

            <span class="flex flex-wrap gap-1.5"> 
                <button v-if="isAddingUser || hasKeys(user) && user.UserId > 0" 
                    class="btn-primary" @click="confirmSave">Save</button>
                <button v-if="!isAddingUser" class="btn-primary"
                    @click="addUser">Add</button>    
                <button v-else class="btn-delete" @click="cancelAdd">Cancel</button>
            </span>

        </div>

        <div v-if="(!user || user.UserId === 0)  && !isAddingUser" class="w-[300px] font-bold">
            No User to display
        </div>

        <div v-if="user && user.UserId > 0 || isAddingUser"  
             class="w-[300px] flex-1 border border-color-blue-gray bg-white">

            <div class="p-5 min-w-[200px] relative grow linear-gray">

                <div v-if="!isAddingUser" class="mb-5 pb-1 flex flex-wrap justify-between">
                    <span class="text-color-dark-blue font-bold whitespace-nowrap text-l">
                        UserName: {{user.UserName}}
                    </span>
                    <span class="text-color-dark-blue font-bold whitespace-nowrap text-l">
                        UserId: {{user.UserId}}
                    </span>
                </div>

                <template v-if="isAddingUser">
                    <TextInput labelName="UserName"     v-model="user.UserName"     :v$ />                
                    <TextInput labelName="UserPassword" v-model="user.UserPassword" :v$ />                
                </template>

                <TextInput labelName="First Name" v-model="user.FirstName" :v$ />
                <TextInput labelName="Last Name"  v-model="user.LastName"  :v$ />
                <TextInput labelName="UserEmail"  v-model="user.UserEmail" :v$ />
                <SelectInput labelName="Role"    v-model="user.Role" :v$ :optionsList="roleList" />
            </div>
        </div>

    </div>

</template>
