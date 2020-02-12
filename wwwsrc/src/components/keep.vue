<template>
  <div class="keep">
    <div class="card" style="width: 18rem;">
      <img :src="keepData.img" class="card-img-top" alt="..." />
      <div class="card-body">
        <h5 class="card-title">{{ keepData.name }}</h5>
        <i class="far fa-edit" title="edit" @click="editKeep(keepData)"></i>
        <i
          class="far fa-times-circle"
          title="delete"
          @click="deleteKeep(keepData.id)"
        ></i>
        <p class="card-text">{{ keepData.description }}</p>
        <i class="far fa-eye" title="view"></i>
        {{ keepData.views }}
        <i class="far fa-bookmark" title="keep"></i>
        {{ keepData.keeps }}
        <i class="fas fa-share" title="share"></i>
        {{ keepData.shares }}
      </div>
    </div>
  </div>
</template>

<script>
import NotificationService from "../NotificationService";
export default {
  name: "keep",
  props: ["keepData"],
  computed: {},
  methods: {
    async editKeep(keep) {
      let keepUpdate = await NotificationService.inputData("Edit keep", keep);
      console.log("keepData and keepUpdate in keep vue", keep, keepUpdate);
      if (keepUpdate) {
        this.$store.dispatch("editKeep", {
          update: keepUpdate,
          id: keep.id
        });
      }
    },
    deleteKeep(keepId) {
      this.$store.dispatch("deleteKeep", keepId);
    }
  }
};
</script>

<style></style>
