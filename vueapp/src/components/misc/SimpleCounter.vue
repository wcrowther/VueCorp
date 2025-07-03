<script setup>

const count = ref(0);
const increment = () => count.value++
const decrement = () => count.value--

</script>

<template>
	<div class="flex justify-start items-center gap-2">
		<button @click="decrement" class="leading-6 text-center size-6 rounded-full bg-slate-300">-</button>
		<TextInput v-model="count" class="mt-[1px] h-6 w-16 text-center" />
		<button @click="increment" class="leading-6 text-center size-6 rounded-full bg-slate-300">+</button>
	</div>
</template>