//
//  MasterViewController.h
//  Anne4Doctique
//
//  Created by Kapi on 21/06/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import <UIKit/UIKit.h>

#import <CoreData/CoreData.h>

typedef enum {
	AnneEntryTypeRecent,
    AnneEntryTypeVDM,
	AnneEntryTypeCNF,
	AnneEntryTypeDTC
} AnneEntryType;

@interface MasterViewController : UIViewController <UITableViewDelegate,UITableViewDataSource,NSFetchedResultsControllerDelegate>{
NSMutableArray *entries;
//AnneFetcher *vdmFetcher;
//WEPopoverController *categoriesPopover;
int currentPage;
NSString *currentCategory;
BOOL loadingExtra;
UIView *loadingExtraMessageView;
BOOL isFirstLoad;
AnneEntryType currentEntryType;
int selectedThemeId;
UIView *loadingView;
}
@property (strong, nonatomic) NSFetchedResultsController *fetchedResultsController;
@property (strong, nonatomic) NSManagedObjectContext *managedObjectContext;


@end
