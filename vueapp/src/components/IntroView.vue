<script setup>

	const authStore				    = useAuthStore()
	const { authUser,isLoggedIn,
    returnUrl,isBusy,expiration }   = storeToRefs(authStore)

    const fullName = computed(() => authUser.value.LastName ? `${authUser.value.FirstName} ${authUser.value.LastName}` : '---')

</script>

<template>
    <div class="h-[600px] flex justify-center items-center">
        <div class="min-h-[15rem] w-[600px] shadow-lg shadow-color-mid-gray border-t
            border-color-light-gray m-auto">

            <div class="w-full p-5 font-bold text-center border-b border-color-mid-gray">Intro-View</div>
            
            <div class="p-5">

                <div class="flex justify-between">
                    <div class="w-40 font-bold">Id:</div>
                    <div class="w-full text-left">{{ authUser.UserId || 0 }}</div>
                </div>

                <div class="flex justify-between">
                    <div class="w-40 font-bold">UserName: </div>
                    <div class="w-full text-left">{{ authUser.UserName }}</div>
                </div>

                <div class="flex justify-between">
                    <div class="w-40 font-bold">Name: </div>
                    <div class="w-full text-left">{{ fullName }}</div>
                </div>
                <div class="flex justify-between">
                    <div class="w-40 font-bold">UserEmail: </div>
                    <div class="w-full text-left">{{ authUser.UserEmail }}</div>
                </div>

                <div class="flex justify-between">
                    <b class="w-40 font-bold">Is LoggedIn: </b>
                    <div class="w-full text-left">{{ isLoggedIn }}</div>
                </div>

                <div class="flex justify-between">
                    <b class="w-40 font-bold">ReturnUrl: </b>
                    <div class="w-full text-left">{{ returnUrl }}</div>
                </div>

                <div class="flex justify-between">
                    <b class="w-40 font-bold">Is Busy: </b>
                    <div class="w-full text-left">{{ isBusy }}</div>
                </div>
                
                <div class="flex justify-between">
                    <b class="w-40 font-bold">Expiration: </b>
                    <div class="w-full text-left">{{ expiration }}</div>
                </div>

                <div class="break-all flex justify-between">
                    <div class="w-40 font-bold">Token: </div>
                    <div class="w-full text-left">{{ authUser.Token || '---'}}</div>
                </div>

            </div>
        </div>

    </div>
</template>