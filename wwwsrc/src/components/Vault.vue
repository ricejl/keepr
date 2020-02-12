<template>
  <div class="name">
    <div class="card" style="width: 10rem;">
      <img src="//placehold.it/100x100" class="card-img-top" alt="..." />
      <div class="card-body">
        {{ vaultData.name }}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "vault",
  props: ["vaultData"],
  methods: {
    // TODO delete vault
  }
};
</script>

<style></style>
