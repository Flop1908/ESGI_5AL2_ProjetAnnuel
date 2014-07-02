//
//  MasterViewController.h
//  Anne&Doctique
//
//  Created by Kapi on 01/07/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface MasterViewController : UITableViewController<UITableViewDelegate, UITableViewDataSource>{
    NSMutableArray *entries;
    IBOutlet UITableView *tableView;
    int currentPage;
	NSString *currentCategory;

    
}
@property (strong,nonatomic) NSString *jsonUrl;
@end
