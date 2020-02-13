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
        <i
          class="fas fa-times"
          title="remove"
          @click="removeKeepFromVault(keepData.id)"
        ></i>
        <p class="card-text">{{ keepData.description }}</p>
        <div>
          <!-- SECTION views -->
          <button class="btn" title="view" @click="viewKeep(keepData)">
            <i class="far fa-eye"></i>
            {{ keepData.views }}
          </button>

          <!-- SECTION keeps -->
          <div class="btn-group">
            <button
              type="button"
              class="btn dropdown-toggle"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
              title="keep"
            >
              <i class="far fa-bookmark"></i>
              {{ keepData.keeps }}
            </button>
            <div class="dropdown-menu">
              <button
                class="dropdown-item"
                type="button"
                v-for="vault in vaults"
                :key="vault.id"
                @click="keepKeep(keepData, vault)"
              >
                {{ vault.name }}
              </button>
            </div>
          </div>

          <!-- SECTION shares -->
          <button class="btn">
            <i class="fas fa-share" title="share"></i>
            {{ keepData.shares }}
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import NotificationService from "../NotificationService";
export default {
  name: "keep",
  props: ["keepData"],
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    async editKeep(keep) {
      let keepUpdate = await NotificationService.inputData("Edit keep", keep);
      if (keepUpdate) {
        this.$store.dispatch("editKeep", {
          update: keepUpdate,
          id: keep.id
        });
      }
    },
    viewKeep(keepData) {
      NotificationService.viewKeep("View", keepData);
      keepData.views++;
      this.$store.dispatch("editKeep", {
        update: keepData,
        id: keepData.id
      });
    },
    keepKeep(keepData, vault) {
      // add to vault by creating vaultkeep
      // must give vaultId and keepId
      this.$store.dispatch("addKeepToVault", {
        keepId: keepData.id,
        vaultId: vault.id
      });
      // increase keep count
      // FIXME increases count even if adding keep is unsuccessful
      // dispatch this next bit within addKeepToVault in store within a try catch
      keepData.keeps++;
      this.$store.dispatch("editKeep", {
        update: keepData,
        id: keepData.id
      });
    },
    deleteKeep(keepId) {
      this.$store.dispatch("deleteKeep", keepId);
    },
    removeKeepFromVault(keepId) {
      this.$store.dispatch(
        "removeKeepFromVault",
        keepId,
        this.$route.params.vaultId
      );
    }
  }
};
</script>

<style></style>
